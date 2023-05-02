import 'package:dartsmiths/core/utils/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';

import '../../../../core/utils/ui_converter.dart';

class AddButton extends StatelessWidget {
  const AddButton({super.key});

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: UIConverter.getComponentWidth(context, 40),
      height: UIConverter.getComponentHeight(context, 55),
      child: FloatingActionButton(
        backgroundColor: secondaryColor,
        onPressed: () => {},
        shape: BeveledRectangleBorder(
            borderRadius: BorderRadius.circular(
                UIConverter.getComponentWidth(context, 2))),
        child: Icon(
          Icons.add,
          color: whiteColor,
        ),
      ),
    );
  }
}
