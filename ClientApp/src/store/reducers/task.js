const INITIAL_STATE = [];

export default function task(state = INITIAL_STATE, action) {
  switch (action.type) {
    case "LOAD_TASK":
      return action.payload;
    case "ADD_TASK":
      return [...state, { id: action.payload.id, name: action.payload.name }];
    case "REMOVE_TASK":
      return state.filter(task => task.id !== action.payload.id);
    default:
      return state;
  }
}
