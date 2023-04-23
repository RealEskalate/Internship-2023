import 'package:dark_knights/features/example/presentation/widgets/clipped_image_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';

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
                    color: Color.fromRGBO(173, 181, 192, 1),
                    spreadRadius: 1,
                    blurRadius: 30,
                    offset: Offset(0, 15),
                  ),
                ],
              ),
              padding: const EdgeInsets.all(8.0),
              child: ClippedImage(
                image: image1,
              ),
            )),
        Expanded(
            flex: flex2,
            child: Container(
              decoration: const BoxDecoration(
                boxShadow: [
                  BoxShadow(
                    color: Color.fromRGBO(173, 181, 192, 1),
                    spreadRadius: 1,
                    blurRadius: 30,
                    offset: Offset(0, 15),
                  ),
                ],
              ),
              padding: const EdgeInsets.all(8.0),
              child: ClippedImage(image: image2),
            ))
      ],
    );
    ;
  }
}
