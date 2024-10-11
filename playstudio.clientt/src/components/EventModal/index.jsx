import React from "react";
import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import InputGroup from "react-bootstrap/InputGroup";
import { useState } from "react";

const BACKEND_URL = "http://localhost:5157";

export const EventModal = (props) => {
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [date, setDate] = useState("");
  const [time, setTime] = useState("");

  const handleSaveEvents = async () => {
    const body = {
      title: title,
      description: description,
      scheduledDateTime: new Date([date, time]).toISOString(),
    };
    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(body),
    };
    await fetch(
      BACKEND_URL + `/clubs/${props.club.id}/events`,
      requestOptions
    );
    props.setShowEventModal(false);
  };

  return (
    <Modal className="event-modal" show={props.show} onHide={props.handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Create an event for club {props.club.name}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
            <Form.Label>Title</Form.Label>
            <Form.Control
              type="text"
              placeholder="Large text"
              onChange={(e) => setTitle(e.target.value)}
            />
          </Form.Group>
          <Form.Group className="mb-3" controlId="exampleForm.ControlTextarea1">
            <Form.Label>Description</Form.Label>
            <Form.Control
              as="textarea"
              rows={3}
              onChange={(e) => setDescription(e.target.value)}
            />
          </Form.Group>
          <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
            <Form.Label>Schedule date time</Form.Label>
            <InputGroup className="mb-3">
              <Form.Control
                onChange={(e) => setDate(e.target.value)}
                type="date"
              />
              <Form.Control
                onChange={(e) => setTime(e.target.value)}
                type="time"
              />
            </InputGroup>
          </Form.Group>
        </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={props.handleClose}>
          Close
        </Button>
        <Button variant="primary" onClick={handleSaveEvents}>
          Save Changes
        </Button>
      </Modal.Footer>
    </Modal>
  );
};
