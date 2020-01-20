export function addCourse(title){
    return {
        type: 'ADD_COURSE',
        payload: {
            title
        }
    };
}

export function removeCourse(id){
    return {
        type: 'REMOVE_COURSE',
        payload: {
            id
        }
    };
}