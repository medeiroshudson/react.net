import React, { useState, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import * as courseActions from "./../../store/actions/course";

import { Card, List, Input, Button } from "antd";

export default function Dashboard() {
  const [input, setInput] = useState("");

  const courses = useSelector(state => state.course);
  const dispatch = useDispatch();

  // loading initial list from api
  useEffect(() => {
    dispatch(courseActions.loadCourse());
  }, [])

  function addCourse() {
    dispatch(courseActions.addCourse(input));
  }

  function removeCourse(id){
    dispatch(courseActions.removeCourse(id));
  }

  return (
    <>
      <Card>
        <Input
          placeholder="Basic usage"
          value={input}
          onChange={event => setInput(event.target.value)}
        />
        <Button
          type="primary"
          onClick={addCourse}
          style={{ marginTop: "16px", marginBottom: "16px" }}
        >
          Adicionar
        </Button>
        <List
          bordered
          dataSource={courses}
          renderItem={item => (
            <List.Item actions={[<Button type="danger" onClick={() => removeCourse(item.id)}>Excluir</Button>]}>
              {item.name}
            </List.Item>
          )}
        />
      </Card>
    </>
  );
}