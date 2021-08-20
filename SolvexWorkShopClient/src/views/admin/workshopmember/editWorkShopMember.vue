<template>
  <section>
    <nav class="navbar">
      <div class="navbar-brand">
        <span class="navbar-item title is-2">Editar miembro del workshop</span>
      </div>
    </nav>

    <form @submit.prevent="validate">
      <b-collapse class="card" animation="slide" aria-id="contentIdForA11y3">
        <template #trigger="props">
          <div
            class="card-header"
            role="button"
            aria-controls="contentIdForA11y3"
          >
            <p class="card-header-title">Datos del miembro del WorkShop</p>
            <a class="card-header-icon">
              <b-icon :icon="props.open ? 'menu-down' : 'menu-up'"> </b-icon>
            </a>
          </div>
        </template>

        <div class="card-content">
          <div class="content">
            <div class="columns is-multiline">
              <div class="column">
                <b-field
                  label="Rol del miembro*"
                  :type="{ 'is-danger': errors.has('role') }"
                  :message="errors.first('role')"
                >
                  <b-select
                    expanded
                    v-model="model.role"
                    placeholder="Requerido"
                    name="role"
                    data-vv-as="Rol del miembro"
                    v-validate="'required'"
                  >
                    <option :value="0">Estudiante</option>
                    <option :value="1">Profesor</option>
                  </b-select>
                </b-field>
              </div>
              <div class="column">
                <b-field
                  label="Seleccione el usuario*"
                  :type="{ 'is-danger': errors.has('userId') }"
                  :message="errors.first('userId')"
                >
                  <b-select
                    expanded
                    name="userId"
                    v-model="model.userId"
                    placeholder="Requerido"
                    data-vv-as="Usuario"
                    v-validate="'required'"
                  >
                    <option
                      v-for="data2 in users"
                      :key="data2.id"
                      :value="data2.id"
                    >
                      {{ data2.name }} {{ data2.lastName }}
                    </option>
                  </b-select>
                </b-field>
              </div>
            </div>
          </div>
        </div>
      </b-collapse>
      <br />

      <nav class="level">
        <!-- Left side -->
        <div class="level-left">
          <p class="level-item">
            <b-button
              :disabled="(modelDoNotChange && !errors.any()) || saving"
              type="is-light"
              @click="clean"
              icon-right="eraser"
              >Reiniciar</b-button
            >
          </p>
          <p class="level-item">
            <b-button
              size="is-medium"
              type="is-warning"
              @click="backToList()"
              icon-left="arrow-left-circle"
              >Volver atrás</b-button
            >
          </p>
        </div>

        <!-- Right side -->
        <div class="level-right">
          <p class="level-item">
            <b-button
              type="is-primary"
              native-type="submit"
              :disabled="errors.any()"
              :loading="saving"
              icon-right="content-save"
              >Guardar</b-button
            >
          </p>
        </div>
      </nav>
    </form>
  </section>
</template>
<script lang="ts">
import { Component, Mixins, Vue } from "vue-property-decorator";
import { AuthMixin, BaseFormEditMixin } from "@/mixins";
import { WorkShopMember } from "@/core/model";
import axios from "axios";

@Component({
  components: {},
})
export default class WorkShopMemberEditComponent extends Mixins<
  BaseFormEditMixin<WorkShopMember>
>(BaseFormEditMixin, AuthMixin) {
  users = [];
  async created() {
    const resUsers = await axios.get("https://localhost:5001/api/user");
    this.users = resUsers.data;
  }

  backToList() {
    this.$router.push(`/admin/workshops/`);
  }

  constructor() {
    super();
    this.controller = "WorkShopMember";
    this.model = new WorkShopMember();
    console.log(this.model.workShopId);
  }

  async getData() {
    try {
      if (this.modelToEdit && !this.loadFromAPI)
        this.model = this.map<WorkShopMember>(this.modelToEdit);
      else {
        this.loading = true;
        const response = await this.service.getById(this.id);
        this.model = response.data;
        this.model.updatedBy = this.$store.state.authModule.user.name;
      }
      this.modelInit = this.map<WorkShopMember>(this.model);
    } catch (errors) {
      this.operationFailedErrors(errors);
    } finally {
      this.loading = false;
    }
  }
}
</script>

<style lang="css">
.p-2rem {
  padding: 2rem;
}
</style>