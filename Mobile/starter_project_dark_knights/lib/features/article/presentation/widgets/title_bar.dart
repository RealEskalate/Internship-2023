import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';

class TitleBar extends StatelessWidget {
  TitleBar({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.fromLTRB(30, 20, 20, 20),
      height: 50,
      child: Stack(children: [
        Align(
          alignment: Alignment.centerLeft,
          child: Container(
              decoration: const BoxDecoration(
                color: textFieldTextColor,
                borderRadius: BorderRadius.all(Radius.circular(13)),
              ),
              padding: const EdgeInsets.fromLTRB(1, 1, 1, 1),
              child: Material(
                color: transparentBlack,
                borderRadius: const BorderRadius.all(Radius.circular(13)),
                child: IconButton(
                    splashColor: tertiaryColor,
                    splashRadius: 100,
                    onPressed: () {},
                    icon: const Icon(
                      Icons.arrow_back_ios_new_sharp,
                      color: tertiaryColor,
                      size: 20,
                    )),
              )),
        ),
        const Align(
            alignment: Alignment.center,
            child: Text(
              'New Article',
              style: titleTextStyle,
            ))
      ]),
    );
  }
}
