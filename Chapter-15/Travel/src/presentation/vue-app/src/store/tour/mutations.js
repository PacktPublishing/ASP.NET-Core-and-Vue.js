import * as types from "./types";

const mutations = {
  [types.GET_TOUR_LISTS](state, lists) {
    state.lists = lists;
  },

  [types.LOADING_TOUR](state, value) {
    state.loading = value;
  },

  [types.REMOVE_TOUR_LIST](state, id) {
    state.lists = state.lists.filter((tl) => tl.id !== id);
    state.packagesOfSelectedCity = [];
  },

  [types.ADD_TOUR_LIST](state, tourList) {
    state.lists.unshift(tourList);
  },

  [types.GET_PACKAGES_OF_SELECTED_CITY](state, packages) {
    state.packagesOfSelectedCity = packages;
  },
};

export default mutations;
