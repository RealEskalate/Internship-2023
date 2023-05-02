import 'package:flutter/material.dart';
import 'package:matador/core/utils/constants/colors.dart';
import 'package:matador/core/utils/constants/styles.dart';
import 'package:matador/core/utils/converters/real_pixel_to_logical_pixel.dart';

class FilterChips extends StatelessWidget {
  const FilterChips({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: convertPixelToScreenHeight(context, 27),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: <Widget>[
          chipBuilder("All", true),
          chipBuilder("Sports", false),
          chipBuilder("Tech", false),
          chipBuilder("Politics", false),
        ],
      ),
    );
  }
}

Widget chipBuilder(String text, bool isSelected) {
  return Builder(builder: (context) {
    return Container(
      height: convertPixelToScreenHeight(context, 27),
      width: convertPixelToScreenHeight(context, 77),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(21.0),
        border: Border.all(
          width: 2,
          color: filterChipsColor,
        ),
        color: isSelected ? filterChipsColor : Colors.white,
      ),
      child: Center(
        child: Text(text,
            style: filterChipsTextStyle.copyWith(
              color: isSelected ? Colors.white : filterChipsColor,
            )),
      ),
    );
  });
}
