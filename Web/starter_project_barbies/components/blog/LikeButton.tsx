import { useState } from "react";
import { GoComment } from "react-icons/go";
import { FaRegClock} from "react-icons/fa";

const LikeButton: React.FC = () => {
  const [likes, setLikes] = useState<number>(0);
  const [isPending, setIsPending] = useState<boolean>(false);

  const handleClick = () => {
    setIsPending(true);
    setTimeout(() => {
      setLikes((prevLikes) => prevLikes + 1);
      setIsPending(false);
    }, 1000); // Set timeout to simulate an asynchronous action
  };

  return (
    <button
      className={`flex items-center space-x-2 rounded-md px-4 py-2 ${
        isPending ? "text-orange-500" : ""}`}
      onClick={handleClick}
    >
      {
      isPending ? (
        <>
          <FaRegClock className="text-orange-500" />
          <span>Pending</span>
        </>
      ) : (
        <>
          <GoComment/>
          <span>{likes} Likes</span>
        </>
      )
      }
    </button>
  );
};

export default LikeButton;

