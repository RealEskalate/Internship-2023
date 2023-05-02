// The purpose of this widget is to create the four grid images
// located at the top of the onboarding screen

import 'dart:ffi';

import 'package:dark_knights/core/utils/colors.dart';
import 'package:dark_knights/features/onboarding/presentation/widgets/onboarding/clipped_image.dart';
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
    List<int> flexes = [flex1, flex2];
    List<String> images = [image1, image2];
    return Row(
      children: [
        for (int i = 0; i < flexes.length; i++)
          Expanded(
              flex: flexes[i],
              child: Container(
                decoration: const BoxDecoration(
                  boxShadow: [
                    BoxShadow(
                      color: imageShadowColor,
                      spreadRadius: 1,
                      blurRadius: 20,
                      offset: Offset(0, 15),
                    ),
                  ],
                ),
                padding: const EdgeInsets.all(8.0),
                child: ClippedImage(
                  image: images[i],
                  radius: MediaQuery.of(context).size.height * 0.045,
                ),
              )),
      ],
    );
  }
}
