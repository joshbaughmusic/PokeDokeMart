import { useEffect, useState } from 'react';
import {
  Accordion,
  AccordionBody,
  AccordionHeader,
  AccordionItem,
  Button,
  Form,
  FormGroup,
  Input,
  Label,
} from 'reactstrap';
import { fetchAllCategories } from '../../../../managers/CategoryManager.js';
import {
  fetchItemsByCategoryId,
} from '../../../../managers/ItemsManager.js';

export const ItemCategories = ({ setAllItems }) => {
  const [categories, setCategories] = useState();
  const [open, setOpen] = useState();
  const toggle = (id) => {
    if (open === id) {
      setOpen();
    } else {
      setOpen(id);
    }
  };

  const getAllCategories = () => {
    fetchAllCategories().then(setCategories);
  };

  useEffect(() => {
    getAllCategories();
  }, []);

  const handleCategorySelect = (e) => {
      fetchItemsByCategoryId(e.target.value).then(setAllItems);
  };

  if (!categories) {
    return (
      <div>
        <Accordion
          open={open}
          toggle={toggle}
          style={{
            borderRadius: '0px',
          }}
        >
          <AccordionItem>
            <AccordionHeader targetId="1">Categories</AccordionHeader>
          </AccordionItem>
        </Accordion>
      </div>
    );
  }

  return (
    <>
      <div>
        <Accordion
          open={open}
          toggle={toggle}
          style={{
            borderRadius: '0px',
          }}
        >
          <AccordionItem>
            <AccordionHeader targetId="1">Categories</AccordionHeader>
            <AccordionBody
              className="text-bg-dark rounded-0"
              accordionId="1"
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
                    />
                  </FormGroup>
                ))}
              </Form>
            </AccordionBody>
          </AccordionItem>
        </Accordion>
      </div>
    </>
  );
};
