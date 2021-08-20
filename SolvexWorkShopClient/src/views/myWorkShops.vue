<template>
  <div class="myWorkShops">

    <h1 class="text-center">
      <strong>WorkShops de {{ this.currentUser.name }} </strong>
    </h1>

    <div class="columns">

        <div  v-for="data in workshopMember" :key="data.id">
          <div class="column" v-if="data.userId === currentUser.id">
            <div v-for="dataWorkShop in workshop" :key="dataWorkShop.id">
              <div v-if="dataWorkShop.id === data.workShopId">
                <div class="card">
                  <div class="card-content">
                    <div class="media">
                      <div class="media-left">
                        <figure
                          class="image is-48x48"
                          :style="{ backgroundColor: randomColor() }"
                        >
                          {{ formatSignature(dataWorkShop.name) }}
                        </figure>
                      </div>
                      <div class="media-content">
                        <p class="title is-4">{{ dataWorkShop.name }}</p>
                        <p class="subtitle is-6">
                          <strong>Rol:</strong> {{ WorkShopMemberRole(data.role) }}
                        </p>
                      </div>
                    </div>

                    <div class="content">
                      {{ dataWorkShop.description }}
                      <br />
                      <small
                        ><strong
                          >{{ formatDate(dataWorkShop.startDate) }} -
                          {{ formatDate(dataWorkShop.endDate) }}</strong
                        ></small
                      >
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

    </div>

  </div>
</template>

<script lang="ts">
import { Component, Mixins } from "vue-property-decorator";
import { AuthMixin } from "@/mixins";
import axios from "axios";
import { WorkShopMember } from "@/core/model";
@Component({
  components: {},
})
export default class MyWorkShops extends Mixins(AuthMixin) {
  workshop = [];
  workshopMember = [];

  async created() {
    const res = await axios.get("https://localhost:5001/api/workshop");
    this.workshop = res.data;
    const member = await axios.get("https://localhost:5001/api/workshopmember");
    this.workshopMember = member.data;
    console.log(res.data);
  }

  randomColor() {
    var colorRandom =
      "#" + (0x1000000 + Math.random() * 0xffffff).toString(16).substr(1, 6);
    return colorRandom;
  }

  WorkShopMemberRole(val: number) {
    return val === 0 ? "Estudiante" : "Profesor";
  }

  formatSignature(element: string): string {
    var element =
      element.split(" ")[0].charAt(0) + "" + element.split(" ")[1].charAt(0);
    return element;
  }
  formatDate(date: string): string {
    var newDate = date.split("T")[0];
    return newDate;
  }
}
</script>

<style>
.myWorkShops {
  padding: 50px;
}
.image {
  padding: 7px;
  font-size: 22px;
  color: white;
}
.text-center {
  font-size: 50px;
  text-align: center;
  margin-bottom: 20px;
}
</style>
