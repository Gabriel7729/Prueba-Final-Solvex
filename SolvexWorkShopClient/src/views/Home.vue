<template>
  <div class="home">
    <h1 class="text-center"><strong>Home</strong></h1>
    <div class="columns">
      <div v-for="element in elements" :key="element.id" class="column">
        <div class="card">
          <div class="card-content">
            <div class="media">
              <div class="media-left">
                <figure class="image is-48x48" :style="{ backgroundColor: randomColor() }">
                {{formatSignature(element.name)}}</figure>
              </div>
              <div class="media-content">
                <p class="title is-4">{{ element.name }}</p>
                <p class="subtitle is-6">@{{ element.createdBy }}</p>
              </div>
            </div>

            <div class="content">
              {{ element.description }}
              <br />
              <small
                ><strong
                  >{{ formatDate(element.startDate)}} -
                  {{ formatDate(element.endDate) }}</strong
                ></small
              >
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "about",
  data() {
    return {
      elements: [],
      colorCache: {},
    };
  },
  methods: {
    randomColor(id) {
      const r = () => Math.floor(256 * Math.random());

      return (
        this.colorCache[0] ||
        (this.colorCache[id] = `rgb(${r()}, ${r()}, ${r()})`)
      );
    },
    formatSignature(element) {
      var element = element.split(" ")[0].charAt(0) + "" + element.split(" ")[1].charAt(0)
      return element;
    },
    formatDate(date){
      var newDate = date.split("T")[0];
      return newDate;
    }
  },
  async created() {
    const res = await axios.get("https://localhost:5001/api/workshop");
    this.elements = res.data.slice(this.elements.length-3)
  },
};
</script>

<style>
.home {
  padding: 50px;
}
.image{
  padding: 7px;
  font-size: 22px;
  color: white;
}
.text-center{
  font-size: 50px;
  text-align: center;
  margin-bottom: 20px;
}
</style>