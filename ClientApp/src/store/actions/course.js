import axios from "axios";

export function loadCourse() {
  const request = axios.get('https://localhost:5001/api/task');
  return {
    type: "LOAD_COURSE",
    payload: request
  };
}

export function addCourse(name) {
  return {
    type: "ADD_COURSE",
    payload: {
      id: Math.random(),
      name
    }
  };
}

export function removeCourse(id) {
  return {
    type: "REMOVE_COURSE",
    payload: {
      id
    }
  };
}
