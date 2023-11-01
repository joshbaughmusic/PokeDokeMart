import { Accordion, Button, Input, Label } from 'reactstrap';
import { ItemSearch } from './ItemSearch.js';
import { ItemSort } from './ItemSort.js';
import { ItemCategories } from './ItemCategories.js';
import { useState } from 'react';

export const SortFilterCategoryShell = ({
  setAllItems,
  getAllItems,
  allItems,
  setItemsPerPage,
  setCurrentPage,
}) => {
  const [open, setOpen] = useState();
  const [selectedCategory, setSelectedCategory] = useState(null);
  const [selectedSort, setSelectedSort] = useState(null);
  const toggle = (id) => {
    if (open === id) {
      setOpen();
    } else {
      setOpen(id);
    }
  };
  const handleReset = () => {
    getAllItems();
    setSelectedCategory(null)
    setSelectedSort(null)
  };

  return (
    <>
      <div className="d-flex flex-column justify-content-between text-bg-dark p-3 filter-shell">
        <div>
          <ItemSearch
            setAllItems={setAllItems}
            allItems={allItems}
          />
          <Accordion
            open={open}
            toggle={toggle}
          >
            <ItemSort
              setAllItems={setAllItems}
              allItems={allItems}
              getAllItems={getAllItems}
              toggle={toggle}
              open={open}
              selectedSort={selectedSort}
              setSelectedSort={setSelectedSort}
            />
            <ItemCategories
              allItems={allItems}
              setAllItems={setAllItems}
              getAllItems={getAllItems}
              toggle={toggle}
              open={open}
              setCurrentPage={setCurrentPage}
              selectedCategory={selectedCategory}
              setSelectedCategory={setSelectedCategory}
            />
          </Accordion>
        </div>
        <Button
          className="mt-3 rounded-0 w-100"
          onClick={handleReset}
        >
          Reset Filters
        </Button>
        <div className="mt-4">
          <Label>Items Per Page:</Label>
          <Input
            className="rounded-0"
            type="select"
            onChange={(e) => setItemsPerPage(e.target.value)}
          >
            <option value={12}>12</option>
            <option value={24}>24</option>
            <option value={36}>36</option>
          </Input>
        </div>
      </div>
    </>
  );
};
