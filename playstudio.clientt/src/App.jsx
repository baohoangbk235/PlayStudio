import { useEffect, useState } from "react";
import "./App.css";
import { EventModal } from "./components/EventModal";
import React from "react";
import Form from "react-bootstrap/Form";
import "bootstrap/dist/css/bootstrap.min.css";
import { ClubModal } from "./components/ClubModal";
import { EventTable } from "./components/EventTable";
import { ClubTable } from "./components/ClubTable";
import { Logos } from "./components/Logos";
import { InputWidgets } from "./components/InputWidgets";
const BACKEND_URL = "http://localhost:5157";

function App() {
  const [clubs, setClubs] = useState([]);
  const [events, setEvents] = useState([]);
  const [showEventModal, setShowEventModal] = useState(false);
  const [showClubModal, setShowClubModal] = useState(false);
  const [selectedClub, setSelectedClub] = useState(null);
  const [showEvents, setShowEvents] = useState(false);
  const [isLoading, setIsLoading] = useState(false);

  useEffect(
    () => {
      populateClubs();
    },
    [isLoading],
    () => {
      setIsLoading(false);
    }
  );

  const populateClubs = async () => {
    const response = await fetch(BACKEND_URL + "/clubs");
    const data = await response.json();
    setClubs(data);
  };

  return (
    <>
      <Logos />
      <InputWidgets
        setShowClubModal={setShowClubModal}
        setClubs={setClubs}
        setShowEvents={setShowEvents}
      />
      <ClubTable
        setShowEvents={setShowEvents}
        setShowEventModal={setShowEventModal}
        setSelectedClub={setSelectedClub}
        setEvents={setEvents}
        clubs={clubs}
      />
      <Form.Text id="eventsInfoText" muted>
        Click into club name to show events
      </Form.Text>
      {selectedClub && (
        <EventModal
          clubName={selectedClub.name}
          show={showEventModal}
          setShowEventModal={setShowEventModal}
          club={selectedClub}
        />
      )}
      <ClubModal
        showClubModal={showClubModal}
        setShowClubModal={setShowClubModal}
        isLoading={isLoading}
        setIsLoading={setIsLoading}
      />
      <br></br>
      <br></br>
      <br></br>
      <EventTable showEvents={showEvents} events={events} />
    </>
  );
}

export default App;
