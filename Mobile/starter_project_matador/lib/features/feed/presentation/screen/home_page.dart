import 'package:flutter/material.dart';
import 'package:matador/core/utils/constants/colors.dart';
import 'package:matador/core/utils/converters/real_pixel_to_logical_pixel.dart';
import 'package:matador/features/feed/presentation/widgets/appbar_title.dart';
import 'package:matador/features/feed/presentation/widgets/menu_icon.dart';
import 'package:matador/features/feed/presentation/widgets/profile_avatar.dart';

class HomePage extends StatelessWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: scaffoldBackGroundColor,
      appBar: AppBar(
        // To remove default elevation from AbbBarr
        bottomOpacity: 0.0,
        elevation: 0.0,
        scrolledUnderElevation: 0,
        toolbarHeight: convertPixelToScreenHeight(context, 45),
        backgroundColor: scaffoldBackGroundColor,

        leading: const MenuIcon(),
        title: const AppBarTitle(),
        actions: const [
          ProfileAvatar(),
        ],
      ),
    );
    // }
  }
}
