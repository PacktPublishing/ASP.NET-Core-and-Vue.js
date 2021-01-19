<template>
  <v-container>
    <div class="text-h4 mb-10">
      Two-week weather forecast of different cities
    </div>
    <div class="v-picker--full-width d-flex justify-center" v-if="loading">
      <v-progress-circular
        :size="70"
        :width="7"
        color="purple"
        indeterminate
      ></v-progress-circular>
    </div>

    <v-select
      @change="fetchWeatherForecast"
      v-model="selectedCity"
      :items="cities"
      label="City"
      persistent-hint
      return-object
      single-line
      clearable
    ></v-select>

    <v-simple-table>
      <template v-slot:default>
        <thead>
          <tr>
            <th class="text-left">Dates</th>
            <th class="text-left">City</th>
            <th class="text-left">&#8451;</th>
            <th class="text-left">&#8457;</th>
            <th class="text-left">Summary</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in weatherForecast" :key="item.date">
            <td>{{ item.date }}</td>
            <td>{{ item.city }}</td>
            <td>{{ item.temperatureC }}</td>
            <td>{{ item.temperatureF }}</td>
            <td>
              <v-chip :color="getColor(item.summary)" dark>{{
                item.summary
              }}</v-chip>
            </td>
          </tr>
        </tbody>
      </template>
    </v-simple-table>
  </v-container>
</template>

<script>
import { getWeatherForecastV2Axios } from "@/api/weather-forecast-services";
import relativeTime from "dayjs/plugin/relativeTime";
import dayjs from "dayjs";
import { mapActions, mapGetters } from "vuex";

export default {
  name: "WeatherForecast",

  async mounted() {
    this.loading = true;
    dayjs.extend(relativeTime);
    await this.fetchWeatherForecast(this.selectedCity);
    this.loading = false;
    await this.getTourListsAction();
    this.cities = this.lists.map((pl) => pl.city);
  },

  data() {
    return {
      weatherForecast: [],
      cities: [],
      selectedCity: "Oslo",
      loading: false,
    };
  },

  methods: {
    ...mapActions("tourModule", ["getTourListsAction"]),
    async fetchWeatherForecast(city = "Oslo") {
      this.loading = true;
      try {
        const { data } = await getWeatherForecastV2Axios(city);
        console.log(data);
        this.weatherForecast = data?.map((w) => {
          const formattedData = { ...w };
          let date = w.date;
          formattedData.date = dayjs(date).fromNow();

          return formattedData;
        });
      } catch (e) {
        alert("Something happened. Please try again.");
      } finally {
        this.loading = false;
      }
    },

    getColor(summary) {
      switch (summary) {
        case "Freezing":
          return "indigo";
        case "Bracing":
          return "blue";
        case "Chilly":
          return "light-blue";
        case "Cool":
          return "cyan";
        case "Mild":
          return "teal";
        case "Warm":
          return "yellow";
        case "Balmy":
          return "amber";
        case "Hot":
          return "orange";
        case "Sweltering":
          return "deep-orange";
        case "Scorching":
          return "red";
        default:
          return "grey";
      }
    },
  },

  computed: {
    ...mapGetters("tourModule", {
      lists: "lists",
    }),
  },
};
</script>