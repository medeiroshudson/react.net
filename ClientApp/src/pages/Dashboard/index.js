import React from "react";
import { useSelector, useDispatch } from "react-redux";
import { Card, List, Button } from "antd";

export default function Dashboard() {
  const courses = useSelector(state => state.data);
  const dispatch = useDispatch();

  function addCourse(){
    dispatch({ type: 'ADD_COURSE', title: 'Teste' })
  }

  return (
    <>
      <Card>
        <h3 style={{ margin: "16px 0" }}>Small Size</h3>
        <List
          size="small"
          bordered
          dataSource={courses}
          renderItem={item => <List.Item>{item}</List.Item>}
        />
        <Button type="primary" onClick={addCourse} style={{ marginTop: "16px" }}>Adicionar</Button>
      </Card>
    </>
  );
}
