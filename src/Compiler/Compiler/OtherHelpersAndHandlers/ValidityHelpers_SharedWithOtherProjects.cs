﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetForHtml5
{
    class ValidityHelpers
    {
        public static void SetValidityLimit(string featureId, DateTime validityLimit)
        {
            RegistryHelpers.SaveSetting("Validity_" + featureId, validityLimit.ToOADate().ToString(CultureInfo.InvariantCulture));
        }

        public static bool IsTheKeyValid(string featureId)
        {
            string value = RegistryHelpers.GetSetting("Validity_" + featureId, null);

            double valueAsDouble;
            if (value != null && double.TryParse(value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out valueAsDouble)) // Note: the "Replace" method is here only for backward compatibility, due to the fact that up to Beta 5 included, we didn't store the value with "InvariantCulture".
            {
                DateTime validityDate = DateTime.FromOADate(valueAsDouble);
                if (DateTime.Today <= validityDate)
                    return true; //the key is still valid
                else
                    return false; //the key is no longer valid
            }
            else
                return true; //We cannot know whether the key is valid or not so we consider that it is (permanent versions).
        }

        public static void RememberThatTheKeyAlmostExpiredMessageWasDisplayedToday()
        {
            RegistryHelpers.SaveSetting("KeyAlmostExpiredMessageLastDisplayDate", DateTime.Today.ToOADate().ToString(CultureInfo.InvariantCulture));
        }

        public static void RemoveKeyValidity(string featureId)
        {
            RegistryHelpers.DeleteSetting("Validity_" + featureId);
        }

        public static bool WasTheKeyAlmostExpiredMessageAlreadyDisplayedToday
        {
            get
            {
                // This method is used to prevent showing the key is almost expired message too many times every day: we only display it once a day.

                string value = RegistryHelpers.GetSetting("KeyAlmostExpiredMessageLastDisplayDate", null);

                double valueAsDouble;
                if (value != null && double.TryParse(value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out valueAsDouble)) // Note: the "Replace" method is here only for backward compatibility, due to the fact that up to Beta 5 included, we didn't store the value with "InvariantCulture".
                {
                    DateTime lastDisplayDate = DateTime.FromOADate(valueAsDouble);
                    if (DateTime.Today == lastDisplayDate)
                        return true; // Means that we have already displayed the Trial message today.
                    else
                        return false;
                }
                else
                    return false;
            }
        }
    }
}