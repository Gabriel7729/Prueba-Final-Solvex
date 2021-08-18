<template>
  <section>
    <nav class="navbar">
      <div class="navbar-brand">
        <span class="navbar-item title is-2">Agregar WorkShopDay</span>
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
                  label="Día*"
                  :type="{ 'is-danger': errors.has('weekDay') }"
                  :message="errors.first('weekDay')"
                >
                  <b-select
                    expanded
                    v-model="model.day"
                    placeholder="Requerido"
                    name="weekDay"
                    data-vv-as="Día"
                    v-validate="'required'"
                  >
                    <option :value="0">Lunes</option>
                    <option :value="1">Martes</option>
                    <option :value="2">Miércoles</option>
                    <option :value="3">Jueves</option>
                    <option :value="4">Viernes</option>
                    <option :value="5">Sábado</option>
                    <option :value="6">Domingo</option>
                  </b-select>
                </b-field>

                <b-field
                  label="Modo del WorkShop*"
                  :type="{ 'is-danger': errors.has('workShopDayMode') }"
                  :message="errors.first('workShopDayMode')"
                >
                  <b-select
                    expanded
                    v-model="model.mode"
                    placeholder="Requerido"
                    name="workShopDayMode"
                    data-vv-as="Modo del WorkShop"
                    v-validate="'required'"
                  >
                    <option :value="0">Presencial</option>
                    <option :value="1">Virtual</option>
                  </b-select>
                </b-field>
              </div>
              <div class="column">
                <!-- <b-field label="Hora de inicio*">
                  <b-timepicker
                    rounded
                    v-model="model.startHour"
                    name="startHour"
                    placeholder="Requerido"
                    data-vv-as="Hora de inicio"
                    icon="clock"
                  >
                  </b-timepicker>
                </b-field> -->

                <b-field
                  label="Hora de inicio*"
                  :type="{ 'is-danger': errors.has('startHour') }"
                  :message="errors.first('startHour')"
                >
                  <b-input
                    v-model="model.startHour"
                    name="startHour"
                    data-vv-as="Hora de inicio"
                    v-validate="'required'"
                    placeholder="Requerido"
                  />
                </b-field>

                <b-field
                  label="Hora de fin"
                >
                  <b-timepicker
                    rounded
                    v-model="model.endHour"
                    name="endHour"
                    placeholder="Requerido"
                    icon="clock"
                  >
                  </b-timepicker>
                </b-field>
              </div>
            </div>
            <div class="colums">
              <div class="column">
                <b-field
                  label="Modo de Ubicación*"
                  :type="{ 'is-danger': errors.has('modeLocation') }"
                  :message="errors.first('modeLocation')"
                >
                  <b-input
                    v-model="model.modeLocation"
                    name="modeLocation"
                    data-vv-as="Modo de Ubicación"
                    v-validate="'required'"
                    placeholder="Requerido"
                  />
                </b-field>
              </div>
            </div>
          </div>
        </div>
      </b-collapse>

      <br />

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
                    v-model="model.workShopId"
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
              type="is-danger"
              :disabled="saving"
              @click="cancel"
              icon-right="cancel"
              >Cancelar</b-button
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
import { Component, Mixins } from "vue-property-decorator";
import { BaseFormAddMixin } from "@/mixins";
import { WorkShopDay } from "@/core/model/workshopday.model";
import WorkShopSelectComponent from "@/components/auth/workShopSelect.vue";
import axios from "axios";
@Component({
  components: {
    WorkShopSelectComponent,
  },
})
export default class WorkShopDayAddComponent extends Mixins<
  BaseFormAddMixin<WorkShopDay>
>(BaseFormAddMixin) {
  hourFormat = undefined;
  enableSeconds = false;
  locale = undefined;

  timespan = require('timespan');
  ts = new this.timespan.TimeSpan(0,0,0,0,1);

  elements = [];
  async created() {
    const res = await axios.get("https://localhost:5001/api/workshop");
    this.elements = res.data;
  }

  constructor() {
    super();
    this.controller = "WorkShopDay";
    this.model = new WorkShopDay();
    this.model.startHour = this.ts;
  }
}
</script>

<style lang="scss" scoped>
</style>