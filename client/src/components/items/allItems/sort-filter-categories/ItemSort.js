import {
  AccordionBody,
  AccordionHeader,
  AccordionItem,
  Form,
  FormGroup,
  Input,
  Label,
} from 'reactstrap';
import { calculateAverageReviewScore } from '../../../utilities/averageReviewScore.js';

const sortValues = [
  {
    name: 'A - Z',
    value: 'a-z',
  },
  {
    name: 'Z - A',
    value: 'z-a',
  },
  {
    name: 'Price (Low to High)',
    value: 'plth',
  },
  {
    name: 'Price (High to Low)',
    value: 'phtl',
  },
  {
    name: 'Avg Reviews (High to Low)',
    value: 'rhtl',
  },
  {
    name: 'Avg Reviews (Low to High)',
    value: 'rlth',
  },
];

export const ItemSort = ({ setAllItems, allItems, selectedSort, setSelectedSort }) => {
  const handleSortSelect = (e) => {
    setSelectedSort(e.target.value)
    const copy = [...allItems];
    if (e.target.value === 'a-z') {
      setAllItems(copy.sort((a, b) => a.name.localeCompare(b.name)));
    } else if (e.target.value === 'z-a') {
      setAllItems(copy.sort((a, b) => b.name.localeCompare(a.name)));
    } else if (e.target.value === 'phtl') {
      setAllItems(copy.sort((a, b) => b.cost - a.cost));
    } else if (e.target.value === 'plth') {
      setAllItems(copy.sort((a, b) => a.cost - b.cost));
    } else if (e.target.value === 'rhtl') {
      setAllItems(
        copy.sort(
          (a, b) =>
            calculateAverageReviewScore(b.reviews) -
            calculateAverageReviewScore(a.reviews)
        )
      );
    } else if (e.target.value === 'rlth') {
      setAllItems(
        copy.sort(
          (a, b) =>
            calculateAverageReviewScore(a.reviews) -
            calculateAverageReviewScore(b.reviews)
        )
      );
    }
  };

  return (
    <>
      <AccordionItem className="rounded-0">
        <AccordionHeader targetId="1">Sort By</AccordionHeader>
        <AccordionBody
          className="text-bg-dark rounded-0"
          accordionId="1"
        >
          <Form>
            {sortValues.map((s, index) => (
              <FormGroup
                key={index}
                check
              >
                <Label>{s.name}</Label>
                <Input
                  name="categoryId"
                  type="radio"
                  value={s.value}
                  onChange={handleSortSelect}
                  checked={s.value === selectedSort}
                />
              </FormGroup>
            ))}
          </Form>
        </AccordionBody>
      </AccordionItem>
    </>
  );
};
