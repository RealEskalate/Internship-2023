import 'package:flutter/material.dart';
import 'package:matador/core/utils/constants/colors.dart';
import 'package:matador/core/utils/constants/styles.dart';
import 'package:matador/core/utils/converters/real_pixel_to_logical_pixel.dart';

class SearchBar extends StatelessWidget {
  const SearchBar({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.symmetric(vertical: convertPixelToScreenHeight(context, 13)),
      height: convertPixelToScreenHeight(context, 50),
      decoration: BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.circular(10),
          boxShadow: const [
            searchBarShadowStyle
          ]),

      child: Row(mainAxisAlignment: MainAxisAlignment.spaceBetween, children: [
        const Padding(
          padding: EdgeInsets.only(left: 15),
          child: Text(
            "Search and article...",
            style: searchBarTextStyle,
          ),
        ),
        Container(
          width: convertPixelToScreenHeight(context, 50),
          height: convertPixelToScreenHeight(context, 50),
          decoration: BoxDecoration(
            color: defaultButtonColor,
            borderRadius: BorderRadius.circular(convertPixelToScreenHeight(context, 10)),
          ),
          child: const Icon(
            Icons.search,
            color: defaultIconColor,
            size: 30,
          ),
        ),
      ]),
    );
  }
}
