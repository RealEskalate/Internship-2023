/** @jest-environment jsdom */
import React from "react";
import { render } from "@testing-library/react";
import "@testing-library/jest-dom";
import { JokeStructure } from "../../features/api/JokesApi";
import JokeCard from "./JokeCard";

describe("JokeCard", () => {
  it("renders a joke and its category correctly", () => {
    const mockJoke: JokeStructure = {
      id: 1,
      joke: "This is a test joke.",
      category: "test category",
    };

    const { getByText } = render(<JokeCard joke={mockJoke} />);
    const linkElement1 = getByText("This is a test joke.");
    const linkElement2 = getByText("test category");

    expect(linkElement1).toBeInTheDocument();
    expect(linkElement2).toBeInTheDocument();
  });
});
