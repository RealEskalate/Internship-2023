import 'package:dark_knights/core/utils/colors.dart';
import 'package:flutter/material.dart';

import 'action_button.dart';

class SearchBar extends StatelessWidget {
  const SearchBar({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    final Size size = MediaQuery.of(context).size;
    const double searchBarHeight = 60;
    final double searchBarPadding = size.height * 0.02;
    return Padding(
      padding: EdgeInsets.all(searchBarPadding),
      child: Material(
        elevation: 3,
        shadowColor: whiteColor,
        borderRadius: BorderRadius.circular(searchBarHeight * 0.16),
        child: Row(
          children: [
            Expanded(
              child: SizedBox(
                height: searchBarHeight,
                child: Center(
                  child: TextField(
                    decoration: InputDecoration(
                      hintText: 'Search and article...',
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
            ActionButton(
              height: searchBarHeight,
              child: Image.asset("assets/images/search_icon.png"),
            )
          ],
        ),
      ),
    );
  }
}
