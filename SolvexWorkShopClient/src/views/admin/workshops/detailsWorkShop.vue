<template>
  <section>
    <nav class="navbar">
      <div class="navbar-brand">
        <span class="navbar-item title is-2"
          >Detalles del {{ this.model.name }}</span
        >
      </div>
    </nav>
    <b-loading :is-full-page="false" :active="loading || saving"></b-loading>

    <b-collapse class="card" animation="slide" aria-id="contentIdForA11y3">
      <template #trigger="props">
        <div
          class="card-header"
          role="button"
          aria-controls="contentIdForA11y3"
        >
          <p class="card-header-title">Datos del WorkShop</p>
          <a class="card-header-icon">
            <b-icon :icon="props.open ? 'menu-down' : 'menu-up'"> </b-icon>
          </a>
        </div>
      </template>

      <div class="card-content">
        <div class="content">
          <div class="columns">
            <div class="column is-two-fifths">
              <div class="card">
                <div class="card-content">
                  <div class="media">
                    <div class="media-left">
                      <figure
                        class="image is-48x48"
                        :style="{ backgroundColor: randomColor() }"
                      >
                        {{ formatSignature(model.name) }}
                      </figure>
                    </div>
                    <div class="media-content">
                      <p class="title is-4">{{ model.name }}</p>
                      <p class="subtitle is-6">@{{ model.createdBy }}</p>
                    </div>
                  </div>

                  <div class="content">
                    {{ model.description }}
                    <br />
                    <small
                      ><strong
                        >{{ formatDate(model.startDate) }} -
                        {{ formatDate(model.endDate) }}</strong
                      ></small
                    >
                  </div>
                </div>
              </div>
            </div>

            <div class="column">
              <div class="card">
                <div class="card-content">
                  <h2 class="text-center">
                    <strong>Horario del {{ model.name }}</strong>
                  </h2>
                  <table
                    class="
                      table
                      is-bordered is-striped is-narrow is-hoverable is-fullwidth
                    "
                  >
                    <thead>
                      <tr>
                        <th>Id</th>
                        <th>Dia</th>
                        <th>Modo</th>
                        <th>Modo ubicación</th>
                        <th>Hora de inicio</th>
                        <th>Hora de fin</th>
                      </tr>
                    </thead>
                    <tbody v-for="data in workshopDay" :key="data.id">
                      <tr v-if="data.workShopId === idWorkShop">
                        <td>{{ data.id }}</td>
                        <td>{{ WeekDay(data.day) }}</td>
                        <td>{{ WorkShopDayMode(data.mode) }}</td>
                        <td>{{ data.modeLocation }}</td>
                        <td>{{ timeFormat(data.startHour) }}</td>
                        <td>{{ timeFormat(data.endHour) }}</td>
                      </tr>
                    </tbody>
                  </table>
                </div>
              </div>
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
          <p class="card-header-title">Miembros del {{ model.name }}</p>
          <a class="card-header-icon">
            <b-icon :icon="props.open ? 'menu-down' : 'menu-up'"> </b-icon>
          </a>
        </div>
      </template>

      <div class="card-content">
        <div class="content">
          <div class="columns">
            <div v-for="data in workShopMember" :key="data.id">
                <div v-if="data.workShopId === idWorkShop">
                  <div v-for="dataUser in users" :key="dataUser.id">
                    <div v-if="dataUser.id === data.userId">
                      <div class="column">
                        <div class="card">
                          <div class="card-content">
                            <div class="media-content">
                              <p class="title is-4">
                                {{ dataUser.name }} {{ dataUser.lastName }}
                              </p>
                              <p class="subtitle is-6">
                                @{{ WorkShopMemberRole(data.role) }}
                              </p>
                              <footer class="card-footer">
                                <a href="#" class="card-footer-item">Edit</a>
                                <a href="#" class="card-footer-item">Delete</a>
                              </footer>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
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
            size="is-medium"
            type="is-warning"
            @click="backToList()"
            icon-left="arrow-left-circle"
            >Volver atrás</b-button
          >
        </p>
      </div>
    </nav>
  </section>
</template>
<script lang="ts">
import { Component, Mixins } from "vue-property-decorator";
import { BaseFormEditMixin } from "@/mixins";
import { WorkShop } from "@/core/model";
import axios from "axios";

@Component({
  components: {},
})
export default class WorkShopViewComponent extends Mixins<
  BaseFormEditMixin<WorkShop>
>(BaseFormEditMixin) {
  idWorkShop? = 0;

  constructor() {
    super();
    this.controller = "WorkShop";
    this.model = new WorkShop();
  }

  WeekDay(val: number) {
    return val === 0
      ? "Lunes"
      : val === 1
      ? "Martes"
      : val === 2
      ? "Miércoles"
      : val === 3
      ? "Jueves"
      : val === 4
      ? "Viernes"
      : val === 5
      ? "Sábado"
      : "Domingo";
  }

  WorkShopMemberRole(val: number) {
    return val === 0 ? "Estudiante" : "Profesor";
  }

  WorkShopDayMode(val: number) {
    return val === 0 ? "Presencial" : "Virtual";
  }

  workshopDay = [];
  workShopMember = [];
  users = [];
  async created() {
    const res = await axios.get("https://localhost:5001/api/workshopday");
    this.workshopDay = res.data;

    const result = await axios.get("https://localhost:5001/api/workshopmember");
    this.workShopMember = result.data;

    const resultUsers = await axios.get("https://localhost:5001/api/user");
    this.users = resultUsers.data;
    console.log(resultUsers.data);
  }

  randomColor() {
    var colorRandom =
      "#" + (0x1000000 + Math.random() * 0xffffff).toString(16).substr(1, 6);
    return colorRandom;
  }

  formatSignature(element: string): string {
    var element =
      element.split(" ")[0].charAt(0) + "" + element.split(" ")[1].charAt(0);
    return element;
  }

  timeFormat(timeValue: Date): string {
    var newTimeValue = timeValue.toString().split(":00+00:00")[0];
    var time = newTimeValue.split("T")[1];
    return time;
  }

  backToList() {
    this.$router.push(`/admin/workshops/`);
  }

  async getData() {
    try {
      if (this.modelToEdit && !this.loadFromAPI)
        this.model = this.map<WorkShop>(this.modelToEdit);
      else {
        this.loading = true;
        const response = await this.service.getById(this.id);
        this.model = response.data;
        this.idWorkShop = this.model.id;
        this.model.startDate = new Date(this.model.startDate as string);
        this.model.endDate = new Date(this.model.endDate as string);
      }
      this.modelInit = this.map<WorkShop>(this.model);
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
.image {
  padding: 7px;
  font-size: 22px;
  color: white;
}
.text-center {
  text-align: center;
}
</style>