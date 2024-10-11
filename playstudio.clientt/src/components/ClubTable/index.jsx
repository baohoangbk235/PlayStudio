import React from "react";
import Button from "react-bootstrap/Button";
import Table from "react-bootstrap/Table";
const BACKEND_URL = "http://localhost:5157";


export const ClubTable = (props) => {
  const handleClickClubName = async (clubId) => {
    props.setShowEvents(true);
    const response = await fetch(BACKEND_URL + `/clubs/${clubId}/events`);
    const data = await response.json();
    props.setEvents(data);
  };

  const handleShowEventModal = (club) => {
    props.setShowEventModal(true);
    props.setSelectedClub(club);
  };

  return (
    <>
      <h3>Game Club</h3>
      <Table>
        <thead>
          <tr>
            <th colSpan={1}>Club</th>
            <th colSpan={7}>Description</th>
            <th colSpan={2}></th>
          </tr>
        </thead>
        <tbody>
          {props.clubs.map((club) => (
            <tr key={club.id}>
              <td
                colSpan={1}
                className="club-name"
                onClick={() => handleClickClubName(club.id)}
              >
                <Button variant="success">{club.name}</Button>
              </td>
              <td colSpan={7}>{club.description}</td>
              <td colSpan={2}>
                <Button
                  variant="primary"
                  onClick={() => handleShowEventModal(club)}
                >
                  Create an event
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </>
  );
};
