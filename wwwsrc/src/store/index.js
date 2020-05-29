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
    activeKeep: {},
    userVaults: [],
    activeVault: {},
    activeVaultKeeps: [],
  },

  mutations: {
    setPublicKeeps(state, keeps) {
      state.publicKeeps = keeps;
    },
    setUserKeeps(state, userKeeps) {
      state.userKeeps = userKeeps;
    },
    setActiveKeep(state, keepData) {
      state.activeKeep = keepData;
    },
    setUserVaults(state, userVaults) {
      state.userVaults = userVaults;
    },
    setActiveVault(state, vaultData) {
      state.activeVault = vaultData;
    },
    setActiveVaultKeeps(state, keepData) {
      state.activeVaultKeeps = keepData;
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
        dispatch("getUserKeeps");
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

    async getUserKeeps({ dispatch, commit }) {
      try {
        let res = await api.get("Keeps/user");
        commit("setUserKeeps", res.data);
      } catch (error) {
        console.error(error);
      }
    },

    async getKeepById({ dispatch, commit }, keepId) {
      try {
        let res = await api.get("keeps/" + keepId);
        commit("setActiveKeep", res.data);
      } catch (error) {
        console.error(error);
      }
    },

    async deleteKeep({ dispatch, commit }, keepId) {
      try {
        await api.delete("Keeps/" + keepId);
        dispatch("getUserKeeps");
      } catch (error) {
        console.error(error);
      }
    },

    // async increaseKeepCount({dispatch, commit}, keepId){
    //   try {
    //     await api.put("Keeps/" + keepId)
    //   } catch (error) {
    //     console.error(error)
    //   }
    // }

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
        let res = await api.get("Vaults/user");
        commit("setUserVaults", res.data);
      } catch (error) {
        console.error(error);
      }
    },

    async getVaultById({ dispatch, commit }, vaultId) {
      try {
        let res = await api.get("Vaults/" + vaultId);
        commit("setActiveVault", res.data);
      } catch (error) {
        console.error(error);
      }
    },

    async deleteVault({ dispatch, commit }, vaultId) {
      try {
        let res = await api.delete("Vaults/" + vaultId);
        dispatch("getVaultsByUser");
      } catch (error) {
        console.error(error);
      }
    },

    // SECTION VaultKeeps
    async createVaultKeep({ dispatch, commit }, newVaultKeep) {
      try {
        let res = await api.post("VaultKeeps", newVaultKeep);
      } catch (error) {
        console.error(error);
      }
    },

    async deleteVaultKeep({ dispatch, commit }, vaultKeepId) {
      try {
        let res = await api.delete("VaultKeeps/" + vaultKeepId);
        dispatch("getKeepsByVaultId", `${this.state.activeVault.id}`);
      } catch (error) {
        console.error(error);
      }
    },

    async getKeepsByVaultId({ dispatch, commit }, vaultId) {
      try {
        let res = await api.get("Vaults/" + vaultId + "/keeps");
        commit("setActiveVaultKeeps", res.data);
      } catch (error) {
        console.error(error);
      }
    },
  },
});
