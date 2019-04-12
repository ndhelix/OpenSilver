﻿
//===============================================================================
//
//  IMPORTANT NOTICE, PLEASE READ CAREFULLY:
//
//  => This code is licensed under the GNU General Public License (GPL v3). A copy of the license is available at:
//        https://www.gnu.org/licenses/gpl.txt
//
//  => As stated in the license text linked above, "The GNU General Public License does not permit incorporating your program into proprietary programs". It also does not permit incorporating this code into non-GPL-licensed code (such as MIT-licensed code) in such a way that results in a non-GPL-licensed work (please refer to the license text for the precise terms).
//
//  => Licenses that permit proprietary use are available at:
//        http://www.cshtml5.com
//
//  => Copyright 2019 Userware/CSHTML5. This code is part of the CSHTML5 product (cshtml5.com).
//
//===============================================================================



using System;

#if MIGRATION
namespace System.Windows
#else
namespace Windows.UI.Xaml
#endif
{
    // Summary:
    //     Represents the method that will handle events raised when a System.Windows.DependencyProperty
    //     is changed on a particular System.Windows.DependencyObject implementation.
    //
    // Parameters:
    //   sender:
    //     The source of the event (typically the object where the property changed).
    //
    //   e:
    //     The event data.
    public delegate void DependencyPropertyChangedEventHandler(object sender, DependencyPropertyChangedEventArgs e);
}