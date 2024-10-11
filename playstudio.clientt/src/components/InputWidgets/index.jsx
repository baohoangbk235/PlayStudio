import { useState } from "react";
import React from "react";
import Button from "react-bootstrap/Button";
import InputGroup from "react-bootstrap/InputGroup";
import Form from "react-bootstrap/Form";
const BACKEND_URL = "http://localhost:5157";

export const InputWidgets = (props) => {
  const [param, setParam] = useState("");

  const handleOnClick = async () => {
    props.setShowEvents(false);
    const response = await fetch(BACKEND_URL + `/clubs/search?param=${param}`);
    const data = await response.json();
    props.setClubs(data);
  };

  const onKeyUp = async (event) => {
    if (event.key === "Enter") {
      await handleOnClick();
    }
  };

  return (
    <InputGroup className="mb-3">
      <Button variant="primary" onClick={() => props.setShowClubModal(true)}>
        Create a club
      </Button>
      <Form.Control
        onChange={(event) => {
          setParam(event.target.value);
        }}
        onKeyUp={(e) => onKeyUp(e)}
        placeholder="Enter club name or description => click search or enter"
        aria-label="Username"
        aria-describedby="basic-addon1"
      />
      <Button onClick={() => handleOnClick()}>Search</Button>
    </InputGroup>
  );
};
