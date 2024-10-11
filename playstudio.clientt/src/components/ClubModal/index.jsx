import React from "react";
import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import { useState } from "react";

const BACKEND_URL = "http://localhost:5157";
export const ClubModal = (props) => {
  const [description, setDescription] = useState("");
  const [name, setName] = useState("");

  const handleSaveClubs = async () => {
    const body = {
      name: name,
      description: description,
    };
    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(body),
    };
    await fetch(BACKEND_URL + `/clubs`, requestOptions);
    props.setIsLoading(!props.isLoading);
    props.setShowClubModal(false);
  };

  return (
    <Modal
      className="club-modal"
      show={props.showClubModal}
      onHide={() => props.setShowClubModal(false)}
    >
      <Modal.Header closeButton>
        <Modal.Title>Create a game club</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
            <Form.Label>Name</Form.Label>
            <Form.Control
              type="text"
              placeholder="Large text"
              onChange={(e) => setName(e.target.value)}
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
        </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button
          variant="secondary"
          onClick={() => props.setShowClubModal(false)}
        >
          Close
        </Button>
        <Button variant="primary" onClick={handleSaveClubs}>
          Save Changes
        </Button>
      </Modal.Footer>
    </Modal>
  );
};
