// The purpose of this widget is to create the four grid images
// located at the top of the onboarding screen

import 'package:dark_knights/core/utils/colors.dart';
import 'package:dark_knights/features/onboarding/presentation/widgets/onboarding/clipped_image_widget.dart';
import 'package:flutter/material.dart';

class UpperRowImages extends StatelessWidget {
  final String image1;
  final String image2;
  final int flex1;
  final int flex2;
  const UpperRowImages(
      {super.key,
      required this.image1,
      required this.image2,
      required this.flex1,
      required this.flex2});

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Expanded(
            flex: flex1,
            child: Container(
              decoration: const BoxDecoration(
                boxShadow: [
                  BoxShadow(
                    color: tertiaryColor,
                    spreadRadius: 1,
                    blurRadius: 30,
                    offset: Offset(0, 15),
                  ),
                ],
              ),
              padding: const EdgeInsets.all(8.0),
              child: ClippedImage(
                image: image1,
                radius: 30,
              ),
            )),
        Expanded(
            flex: flex2,
            child: Container(
              decoration: const BoxDecoration(
                boxShadow: [
                  BoxShadow(
                    color: tertiaryColor,
                    spreadRadius: 1,
                    blurRadius: 30,
                    offset: Offset(0, 15),
                  ),
                ],
              ),
              padding: const EdgeInsets.all(8.0),
              child: ClippedImage(
                image: image2,
                radius: 30,
              ),
            ))
      ],
    );
    ;
  }
}
