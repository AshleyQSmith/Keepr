import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 9000,
  withCredentials: true,
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    usersKeeps: [],
    usersVaults: [],
  },
  mutations: {
    // addKeep(state, keepData) {
    //   state.publicKeeps = keepData;
    // },
    setPublicKeeps(state, keeps) {
      state.publicKeeps = keeps;
    },
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },

    async createKeep({ dispatch, commit }, newKeep) {
      try {
        let res = await api.post("Keeps", newKeep);
        dispatch("getPublicKeeps");
        // commit("addKeep", newKeep);
      } catch (error) {
        console.error(error);
      }
    },

    async getPublicKeeps({ dispatch, commit }) {
      try {
        let res = await api.get("keeps");
        commit("setPublicKeeps", res.data);
      } catch (error) {
        console.error(error);
      }
    },
  },
});
