import * as types from "./types";
import {
  getTourListsAxios,
  deleteTourListAxios,
  postTourListAxios,
} from "@/store/tour/services";

// asynchronous action using Axios
export async function getTourListsAction({ commit }) {
  commit(types.LOADING_TOUR, true);

  try {
    const { data } = await getTourListsAxios();
    commit(types.GET_TOUR_LISTS, data.lists);
  } catch (e) {
    alert(e);
    console.log(e);
  }

  commit(types.LOADING_TOUR, false);
}

// asynchronous action using Axios
export async function removeTourListAction({ commit }, payload) {
  commit(types.LOADING_TOUR, true);

  try {
    await deleteTourListAxios(payload);
    commit(types.REMOVE_TOUR_LIST, payload);
  } catch (e) {
    alert(e);
    console.log(e);
  }

  commit(types.LOADING_TOUR, false);
}

// asynchronous action using Axios
export async function addTourListAction({ commit }, payload) {
  commit(types.LOADING_TOUR, true);

  try {
    const { data } = await postTourListAxios(payload);
    payload.id = data; // storing the id from the response int of ASP.NET Core, which will be used in the UI.
    payload.tourPackages = []; // initialize the tourPackages of the newly created tourList
    commit(types.ADD_TOUR_LIST, payload);
  } catch (e) {
    alert(e);
    console.log(e);
  }

  commit(types.LOADING_TOUR, false);
}

// non-asynchronous action
export function getPackagesOfSelectedCityAction({ commit }, payload) {
  commit(types.GET_PACKAGES_OF_SELECTED_CITY, payload);
}
