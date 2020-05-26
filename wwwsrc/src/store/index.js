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
    userKeeps: [],
    userVaults: [],
  },

  mutations: {
    setPublicKeeps(state, keeps) {
      state.publicKeeps = keeps;
    },
    setUserKeeps(state, userKeeps) {
      state.userKeeps = userKeeps;
    },
    setUserVaults(state, userVaults) {
      state.userVaults = userVaults;
    },
  },

  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },

    // SECTION Keeps

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

    async getUserKeeps({ dispatch, commit }, userId) {
      try {
        let res = await api.get("Keeps/user");
        commit("setUserKeeps", res.data);
      } catch (error) {
        console.error(error);
      }
    },

    async deleteKeep({ dispatch, commit }, keepId) {
      try {
        await api.delete("Keeps/" + keepId);
        dispatch("getPublicKeeps");
      } catch (error) {
        console.error(error);
      }
    },

    // SECTION Vaults
    async createVault({ dispatch, commit }, newVault) {
      try {
        let res = await api.post("Vaults", newVault);
        dispatch("getVaultsByUser");
      } catch (error) {
        console.error(error);
      }
    },

    async getVaultsByUser({ dispatch, commit }) {
      try {
        let res = await api.get("Vaults");
        commit("setUserVaults", res.data);
      } catch (error) {
        console.error(error);
      }
    },
  },
});
