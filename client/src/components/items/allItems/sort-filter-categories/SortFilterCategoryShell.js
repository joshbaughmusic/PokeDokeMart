import { Button, Container, Input, Label } from 'reactstrap';
import { ItemSearch } from './ItemSearch.js';
import { ItemSort } from './ItemSort.js';
import { ItemCategories } from './ItemCategories.js';

export const SortFilterCategoryShell = ({
  setAllItems,
  getAllItems,
  allItems,
  setItemsPerPage,
}) => {
  const handleReset = () => {
    getAllItems();
  };

  return (
    <>
      <div
        style={{
          marginTop: '15px',
        }}
      >
        <ItemSearch
          setAllItems={setAllItems}
          allItems={allItems}
        />
        <ItemSort
          setAllItems={setAllItems}
          allItems={allItems}
          getAllItems={getAllItems}
        />
        <ItemCategories
          setAllItems={setAllItems}
          getAllItems={getAllItems}
        />
        <Button
          className="mt-4"
          onClick={handleReset}
        >
          Reset
        </Button>
        <div className="mt-4">
          <Label>Items Per Page:</Label>
          <Input
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
