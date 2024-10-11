import React from "react";
import Table from "react-bootstrap/Table";
import Alert from "react-bootstrap/Alert";

export const EventTable = (props) => {
  return (
    <>
      {props.showEvents && (
        <div>
          <h3>Game Events</h3>
          {props.events.length > 0 ? (
            <Table>
              <thead>
                <tr>
                  <th>Title</th>
                  <th>Description</th>
                  <th>Scheduled Date Time</th>
                </tr>
              </thead>
              <tbody>
                {props.events.map((event) => (
                  <tr key={event.id}>
                    <td>{event.title}</td>
                    <td>{event.description}</td>
                    <td>{new Date(event.scheduledDateTime).toString()}</td>
                  </tr>
                ))}
              </tbody>
            </Table>
          ) : (
            <Alert key="info" variant="info">
              There is no events for this club at the moment.
            </Alert>
          )}
        </div>
      )}
    </>
  );
};
