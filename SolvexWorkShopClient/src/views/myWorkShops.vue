<template>
  <div class="myWorkShops">
    <h1 class="text-center"><strong>WorkShops de {{this.currentUser.name}} </strong></h1>
    <div class="columns">
      <div v-for="data in workshop" :key="data.id" class="column">
        <div class="card">
          <div class="card-content">
            <div class="media">
              <div class="media-left">
                <figure
                  class="image is-48x48"
                  :style="{ backgroundColor: randomColor() }"
                >
                  {{ formatSignature(data.name) }}
                </figure>
              </div>
              <div class="media-content">
                <p class="title is-4">{{ data.name }}</p>
                <p class="subtitle is-6">@{{ data.createdBy }}</p>
              </div>
            </div>

            <div class="content">
              {{ data.description }}
              <br />
              <small
                ><strong
                  >{{ formatDate(data.startDate) }} -
                  {{ formatDate(data.endDate) }}</strong
                ></small
              >
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
@Component({
  components: {
  },
})
export default class MyWorkShops extends Mixins(AuthMixin) {

  workshop = [];
  elements = [];
  
  async created() {
    const res = await axios.get("https://localhost:5001/api/workshop");
    this.workshop = res.data;
    const member = await axios.get("https://localhost:5001/api/workshopmember");
    this.elements = member.data;
    console.log(res.data)
  }

  randomColor() {
    var colorRandom = "#" + (0x1000000 + Math.random() * 0xffffff).toString(16).substr(1, 6);
    return colorRandom;
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
