import 'package:flutter/material.dart';

import '../../../../core/utils/colors.dart';

class NextPointer extends StatefulWidget {
  const NextPointer({super.key});

  @override
  State<NextPointer> createState() => _NextPointerState();
}

class _NextPointerState extends State<NextPointer> {
  int index = 0;
  void _setIndex() {
    setState(() {
      index = (index + 1) % 3;
    });
  }

  final double height = 8;
  final double width = 23;

  List<Decoration> decoration = [
    BoxDecoration(
      borderRadius: BorderRadius.circular(5.0),
      color: primaryColor,
    ),
    BoxDecoration(
      borderRadius: BorderRadius.circular(5.0),
      color: scaffoldBackground,
    )
  ];

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Container(
              decoration: index == 0 ? decoration[0] : decoration[1],
              height: height, //height size is constant
              width: index == 0
                  ? width
                  : height, // width == height if it is not active.
            ),
            Padding(
              padding: const EdgeInsets.all(10.0),
              child: Container(
                height: height, //height size is constant
                width: index == 1 ? width : height, //width size
                decoration: index == 1 ? decoration[0] : decoration[1],
              ),
            ),
            Container(
                height: height, //height size is constant
                width: index == 2 ? width : height, //width size
                decoration: index == 2 ? decoration[0] : decoration[1]),
          ],
        ),
        Column(
          children: [
            GestureDetector(
              onTap: _setIndex,
              child: Container(
                height: 60,
                width: 88,
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(12.0),
                  color: primaryColor,
                ),
                child: const Icon(
                  Icons.navigate_next_outlined,
                  color:whiteColor,
                ),
              ),
            )
          ],
        ),
      ],
    );
  }
}
