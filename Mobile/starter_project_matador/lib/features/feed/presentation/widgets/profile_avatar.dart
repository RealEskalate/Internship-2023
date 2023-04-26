import 'package:flutter/material.dart';
import 'package:matador/core/utils/constants/colors.dart';
import 'package:matador/core/utils/converters/real_pixel_to_logical_pixel.dart';

class ProfileAvatar extends StatelessWidget {
  const ProfileAvatar({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Stack(children: [
      Padding(
        padding: const EdgeInsets.only(right: 15, top: 4),
        child: CircleAvatar(
            backgroundImage: const AssetImage(
              "assets/images/profile_image.jpg",
            ),
            radius: convertPixelToScreenHeight(context, 21)),
      ),

      // Circular ring on the profile avatar
      Padding(
        padding: const EdgeInsets.only(right: 15, top: 4),
        child: SizedBox(
            height: convertPixelToScreenHeight(context, 42),
            width: convertPixelToScreenHeight(context, 42),
            child: Center(
              child: Container(
                width: convertPixelToScreenHeight(context, 37),
                height: convertPixelToScreenHeight(context, 37),
                decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(
                        convertPixelToScreenHeight(context, 20)),
                    border: Border.all(
                      color: profileAvatarCircularRingColor,
                      width: 1.5,
                    )),
              ),
            )),
      ),
    ]);
  }
}