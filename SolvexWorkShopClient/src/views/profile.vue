<template>
  <div class="profile">
    <h1 class="text-center">
      <strong>Perfil de {{ this.currentUser.name }} </strong>
    </h1>
    <div class="columns">
      <div v-for="data in users" :key="data.id" style="margin-left:27.5rem;" class="column is-three-fifths is-offset-one-fifth">
        <div v-if="data.id === id" class="card " style="width:20rem;">
          <div class="card-image">
            <figure class="image is-2by2">
              <img
                src="@/assets/images/gabriel.jpeg"
                alt="Placeholder image"
              />
            </figure>
          </div>
          <div class="card-content">
            <div class="media">
              <div class="media-left">
                <figure
                
                  class="image is-48x48"
                  :style="{ backgroundColor: randomColor() }"
                >
                  {{ formatSignature(data.name + " " + data.lastName) }}
                </figure>
              </div>
              <div class="media-content">
                <p class="title is-4">
                  {{ data.name }} {{ data.middleName }} {{ data.lastName }}
                  {{ data.secondLastName }}
                </p>
                <p class="subtitle is-6">@{{ data.userName }}</p>
              </div>
            </div>

            <div class="content">
              {{ data.documentTypeValue }}
              <br />
              <small
                ><strong>{{ formatDate(data.dob) }}</strong></small
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
  components: {},
})
export default class Profile extends Mixins(AuthMixin) {
  users = [];
  id = this.$store.state.authModule.user.id;
  async created() {
    const member = await axios.get("https://localhost:5001/api/user");
    this.users = member.data;
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
  formatDate(date: string): string {
    var newDate = date.split("T")[0];
    return newDate;
  }
}
</script>

<style>
.profile {
  padding: 30px;
}
.image {
  padding: 8px;
  font-size: 22px;
  color: white;
  border-radius: 50%;
}
.text-center {
  font-size: 50px;
  text-align: center;
  margin-bottom: 20px;
}
</style>