const INITIAL_STATE = [];

export default function course(state = INITIAL_STATE, action) {
  switch (action.type) {
    case "ADD_COURSE":
      return [...state, { id: Math.random(), title: action.payload.title }];
    case "REMOVE_COURSE":
      return state.filter(course => course.id !== action.payload.id);
    default:
      return state;
  }
}
