import React, { useState, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import * as taskActions from "./../../store/actions/task";

import { Card, List, Input, Button } from "antd";

export default function Dashboard() {
  const [input, setInput] = useState("");

  const tasks = useSelector(state => state.task);
  const dispatch = useDispatch();

  // loading initial list from api
  useEffect(() => {
    dispatch(taskActions.loadTask());
  }, [])

  function addTask() {
    dispatch(taskActions.addTask(input));
    setInput("")
  }

  function removeTask(id){
    dispatch(taskActions.removeTask(id));
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
          onClick={addTask}
          style={{ marginTop: "16px", marginBottom: "16px" }}
        >
          Adicionar
        </Button>
        <List
          bordered
          dataSource={tasks}
          renderItem={item => (
            <List.Item actions={[<Button type="danger" onClick={() => removeTask(item.id)}>Excluir</Button>]}>
              {item.name}
            </List.Item>
          )}
        />
      </Card>
    </>
  );
}