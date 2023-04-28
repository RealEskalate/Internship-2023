import 'package:dartsmiths/core/utils/colors.dart';
import 'package:flutter/material.dart';
import '../../../../core/utils/ui_converter.dart';

class like_button extends StatelessWidget {
  like_button({super.key});
  String likes = '2.3k';

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: UIConverter.getComponentWidth(context, 22),
      width: UIConverter.getComponentWidth(context, 50),
      child: FloatingActionButton(
          onPressed: () {},
          shape: BeveledRectangleBorder(
              borderRadius:
                  BorderRadius.circular(UIConverter.designWidth * 0.01)),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceAround,
            children: [
              const Icon(
                Icons.thumb_up_alt_outlined,
                color: whiteColor,
              ),
              Text(
                likes,
                style: const TextStyle(color: whiteColor),
              ),
            ],
          ) //child widget inside this button

          ),
    );
  }
}
