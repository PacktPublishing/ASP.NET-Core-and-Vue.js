import * as types from "./types";

const mutations = {
  [types.GET_TOUR_LISTS](state, lists) {
    state.lists = lists;
  },

  [types.LOADING_TOUR](state, value) {
    state.loading = value;
  },

  [types.REMOVE_TOUR_LIST](state, id) {
    state.lists = state.lists.filter(tl => tl.id !== id);
    state.packagesOfSelectedCity = [];
  },

  [types.ADD_TOUR_LIST](state, tourList) {
    state.lists.unshift(tourList);
  },

  [types.GET_PACKAGES_OF_SELECTED_CITY](state, packages) {
    state.packagesOfSelectedCity = packages;
  },

  [types.REMOVE_TOUR_PACKAGE](state, id) {
    state.packagesOfSelectedCity = state.packagesOfSelectedCity.filter(
      tp => tp.id !== id
    );
  },

  [types.ADD_TOUR_PACKAGE](state, tourPackage) {
    state.packagesOfSelectedCity.unshift(tourPackage);
  },

  [types.UPDATE_TOUR_PACKAGE](state, payload) {
    const packageIndex = state.packagesOfSelectedCity.findIndex(
      pl => pl.id === payload.id
    );
    state.packagesOfSelectedCity[packageIndex] = payload;

    const listIndex = state.lists.findIndex(
      l => l.id === state.packagesOfSelectedCity.listId
    );
    state.lists[listIndex] = state.packagesOfSelectedCity;
  }
};

export default mutations;
