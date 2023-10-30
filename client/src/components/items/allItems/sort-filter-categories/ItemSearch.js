import { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { Container, Form, FormGroup, Input, Label } from 'reactstrap';
import "./sortFilterCategory.css"

export const ItemSearch = ({ allItems }) => {
  const [searchResults, setSearchResults] = useState([]);
  const navigate = useNavigate()
  const handleSearch = (e) => {
    const copy = [...allItems];

    if (e.target.value === "") {
      setSearchResults([])
    } else {
      setSearchResults(copy.filter((i) =>
        i.name.toLowerCase().includes(e.target.value.toLowerCase())
      ));
    }

  };

  return (
    <>
      <div>
        <Form>
          <FormGroup className="position-relative">
            <Input
              placeholder="Search..."
              onChange={handleSearch}
              className="rounded-0"
            />
            <div
              className="position-absolute"
              style={{
                overflow: 'auto',
                maxHeight: '300px',
                zIndex: '100',
                backgroundColor: 'white',
                color: 'black',
                width: '100%',
                boxShadow: '8px 8px 20px rgba(0, 0, 0, 1)',
              }}
            >
              {searchResults.length > 0
                ? searchResults.map((i, index) => (
                    <p
                      className="searchResultItem"
                      onClick={() => navigate(`/items/${i.id}`)}
                    >
                      {i.name}
                    </p>
                  ))
                : ''}
            </div>
          </FormGroup>
        </Form>
      </div>
    </>
  );
};
