import api from "@/api/api-v1-config";

export async function getTourListsAxios() {
  return await api.get("TourLists");
}

export async function deleteTourListAxios(id) {
  return await api.delete("TourLists/" + id);
}

export async function postTourListAxios(tourList) {
  return await api.post("TourLists", tourList);
}

export async function deleteTourPackageAxios(id) {
  return await api.delete("TourPackages/" + id);
}

export async function postTourPackageAxios(tourPackage) {
  return await api.post("TourPackages", tourPackage);
}

export async function putTourPackageAxios(tourPackage) {
  return await api.put(`TourPackages/${tourPackage.id}`, tourPackage);
}
