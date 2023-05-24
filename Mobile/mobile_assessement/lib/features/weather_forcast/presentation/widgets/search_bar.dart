import '../../../../core/utils/colors.dart';
import 'package:flutter/material.dart';

import 'action_button.dart';

class SearchBar extends StatelessWidget {
  const SearchBar({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    final Size size = MediaQuery.of(context).size;
    const double searchBarHeight = 50;
    final double searchBarPadding = size.height * 0.02;
    return Padding(
      padding: EdgeInsets.all(searchBarPadding),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Expanded(
            child: Material(
              elevation: 2,
              borderRadius: BorderRadius.circular(10),
              child: SizedBox(
                height: searchBarHeight,
                child: Center(
                  child: TextField(
                    decoration: InputDecoration(
                      hintText: 'Search a new city...',
                      hintStyle: const TextStyle(
                          fontFamily: "Poppins", fontWeight: FontWeight.w100),
                      border: InputBorder.none,
                      contentPadding:
                          EdgeInsets.symmetric(horizontal: size.width * 0.04),
                    ),
                  ),
                ),
              ),
            ),
          ),
          SizedBox(
            width: 8,
          ),
          ActionButton(
            height: 35,
            child: Text("search"),
          )
        ],
      ),
    );
  }
}
