import Input from "../../components/FormUI/Input";
import ClipLoader from "react-spinners/ClipLoader";
import { useGetJokesQuery } from "../api/JokesApi";
import JokeCard from "../../components/Jokes/JokeCard";
import { RootState } from "../../store/index";
import { useDispatch, useSelector } from "react-redux";
import { setNumberOfItems, setSearchKeyword } from "./JokesSlice";
import Error from "../../components/Jokes/ErrorCard";
import ErrorCard from "../../components/Jokes/ErrorCard";
function JokesList() {
  const { numberOfItems, searchKeyword } = useSelector(
    (state: RootState) => state.jokes
  );

  const dispatch = useDispatch();
  const {
    data: fetchedData,
    isLoading,
    isFetching,
  } = useGetJokesQuery({
    amount: numberOfItems,
    contains: searchKeyword,
  });

  let content;

  if (isLoading || isFetching) {
    content = <ClipLoader color={"#000080"} loading={true} size={100} />;
  } else if (fetchedData?.error) {
    content = (
      <ErrorCard message={fetchedData.message} causedBy={fetchedData.causedBy} />
    );
  } else {
    content = (
      <div className="w-full">
        {fetchedData?.jokes!.map((item) => (
          <JokeCard joke={item} key={item.id} />
        ))}
      </div>
    );
  }

  return (
    <div className="w-full flex flex-col p-5 gap-3 items-center overflow-auto">
      <div className="w-full">
        <div className="w-52 items-start">
          <Input
            onChange={(val) => dispatch(setSearchKeyword(val))}
            value={searchKeyword ?? ""}
            placeholder="Search jokes..."
          />
        </div>
      </div>

      {content}

      {/* Items per page Dropdown */}
      <div className="">
        <label
          className="mr-2 text-xl font-bold text-gray-800"
          htmlFor="itemsPerPage"
        >
          Number of items:
        </label>
        <select
          id="itemsPerPage"
          className="border rounded px-3 py-2 bg-white text-gray-800 font-bold hover:cursor-pointer"
          value={numberOfItems}
          onChange={(e) => dispatch(setNumberOfItems(Number(e.target.value)))}
        >
          <option value={5}>5</option>
          <option value={10}>10</option>
          <option value={15}>15</option>
          <option value={20}>20</option>
        </select>
      </div>
    </div>
  );
}

export default JokesList;
