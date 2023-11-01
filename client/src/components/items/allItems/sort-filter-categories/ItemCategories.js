import { useEffect, useState } from 'react';
import {
  AccordionBody,
  AccordionHeader,
  AccordionItem,
  Form,
  FormGroup,
  Input,
  Label,
} from 'reactstrap';
import { fetchAllCategories } from '../../../../managers/CategoryManager.js';
import {
  fetchItemsByCategoryId,
} from '../../../../managers/ItemsManager.js';

export const ItemCategories = ({
  setAllItems,
  setCurrentPage,
  selectedCategory,
  setSelectedCategory,
}) => {
  const [categories, setCategories] = useState();

  const getAllCategories = () => {
    fetchAllCategories().then(setCategories);
  };

  useEffect(() => {
    getAllCategories();
  }, []);

  const handleCategorySelect = (e) => {
    setSelectedCategory(e.target.value);
    fetchItemsByCategoryId(e.target.value).then((res) => {
      setAllItems(res);
      setCurrentPage(1);
    });
  };

  if (!categories) {
    return (
      <AccordionItem className="rounded-0">
        <AccordionHeader targetId="2">Categories</AccordionHeader>
      </AccordionItem>
    );
  }

  return (
    <>
      <AccordionItem className="rounded-0">
        <AccordionHeader targetId="2">Categories</AccordionHeader>
        <AccordionBody
          className="text-bg-dark rounded-0"
          accordionId="2"
        >
          <Form>
            {categories.map((c, index) => (
              <FormGroup
                key={index}
                check
              >
                <Label>{c.name}</Label>
                <Input
                  name="categoryId"
                  type="radio"
                  value={c.id}
                  onChange={handleCategorySelect}
                  checked={c.id === parseInt(selectedCategory)}
                />
              </FormGroup>
            ))}
          </Form>
        </AccordionBody>
      </AccordionItem>
    </>
  );
};
