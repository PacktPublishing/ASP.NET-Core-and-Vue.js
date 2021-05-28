import * as types from "./types";

const mutations = {
  [types.GET_TOUR_LISTS](state, lists) {
    state.lists = lists;
  },

  [types.LOADING_TOUR](state, value) {
    state.loading = value;
  }
};

export default mutations;
