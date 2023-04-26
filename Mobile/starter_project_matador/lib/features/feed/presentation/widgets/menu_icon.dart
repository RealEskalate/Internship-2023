import 'package:flutter/material.dart';
import 'package:matador/core/utils/constants/colors.dart';
import 'package:matador/features/feed/presentation/widgets/menu_alt_right_icon.dart';
import 'package:matador/core/utils/converters/real_pixel_to_logical_pixel.dart';

class MenuIcon extends StatelessWidget {
  const MenuIcon({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Icon(
      MenuAltRight.vector, // Custom Icon data
      color: menuIconColor,
      size: convertPixelToScreenHeight(context, 20),
      shadows: const [
        BoxShadow(
            color: menuIconShadowColor, offset: Offset(0, 4), blurRadius: 4),
      ],
    );
  }
}
