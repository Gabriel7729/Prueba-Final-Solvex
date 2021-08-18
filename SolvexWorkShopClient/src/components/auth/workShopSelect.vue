<template>
  <section>
      <b-collapse class="card" animation="slide" aria-id="contentIdForA11y3">
        <template #trigger="props">
          <div
            class="card-header"
            role="button"
            aria-controls="contentIdForA11y3"
          >
            <p class="card-header-title">Datos del WorkShopDay</p>
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
                  label="Modo del WorkShop*"
                  :type="{ 'is-danger': errors.has('workShopDayMode') }"
                  :message="errors.first('workShopDayMode')"
                >
                  <b-select
                    expanded
                    v-model="model.name"
                    placeholder="Requerido"
                    data-vv-as="Modo del WorkShop"
                    v-validate="'required'"
                  >
                    <option
                      v-for="data in elements"
                      :key="data.id"
                      :value="data.id"
                    >
                      {{ data.name }}
                    </option>
                  </b-select>
                </b-field>
              </div>
            </div>
          </div>
        </div>
      </b-collapse>
  </section>
</template>
<script lang="ts">
import { Component, Mixins } from "vue-property-decorator";
import { BaseFormAddMixin } from "@/mixins";
import { WorkShop } from "@/core/model";
import axios from "axios";
@Component
export default class WorkShopSelectComponent extends Mixins<
  BaseFormAddMixin<WorkShop>
>(BaseFormAddMixin) {
    elements = [];
  async created() {
    const res = await axios.get("https://localhost:5001/api/workshop");
    this.elements = res.data;
  }
  constructor() {
    super();
    this.controller = "WorkShop";
    this.model = new WorkShop();
  }
}
</script>

<style lang="scss" scoped>
</style>