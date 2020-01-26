const INITIAL_STATE = [];

export default function course(state = INITIAL_STATE, action) {
  switch (action.type) {
    case "LOAD_COURSE":
      return action.payload.data;
    case "ADD_COURSE":
      return [...state, { id: action.payload.id, name: action.payload.name }];
    case "REMOVE_COURSE":
      return state.filter(course => course.id !== action.payload.id);
    default:
      return state;
  }
}
