import axios from "axios";

export function loadTask() {
  return dispatch => {
    axios
      .get("https://localhost:5001/api/task")
      .then(response => dispatch({ type: "LOAD_TASK", payload: response.data }))
      .catch(error => console.error(error));
  };
}

export function addTask(name) {
  return dispatch => {
    axios
      .post("https://localhost:5001/api/task", { name })
      .then(response => dispatch({ type: "ADD_TASK", payload: response.data }))
      .then(response => dispatch(loadTask()));
  };
}

export function removeTask(id) {
  return dispatch => {
    axios
      .delete(`https://localhost:5001/api/task?id=${id}`)
      .then(response => dispatch({ type: "REMOVE_TASK", payload: response.data }))
      .then(response => dispatch(loadTask()))
  }
}
