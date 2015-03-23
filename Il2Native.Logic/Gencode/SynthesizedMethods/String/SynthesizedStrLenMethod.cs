﻿namespace Il2Native.Logic.Gencode.SynthesizedMethods.String
{
    using System.Collections.Generic;
    using PEAssemblyReader;

    /// <summary>
    /// </summary>
    public class SynthesizedStrLenMethod : SynthesizedInlinedTextMethod
    {
        private readonly IMethodBody _methodBody;

        private readonly IList<IParameter> _parameters;

        private readonly IList<object> _tokenResolutions;

        /// <summary>
        /// </summary>
        /// <param name="type">
        /// </param>
        /// <param name="typeResolver">
        /// </param>
        public SynthesizedStrLenMethod(ITypeResolver typeResolver)
            : base("strlen", typeResolver.System.System_String, typeResolver.System.System_Int32)
        {
            byte[] code;
            IList<object> tokenResolutions;
            IList<IType> locals;
            IList<IParameter> parameters;
            StringGen.GetStrLen(typeResolver, out code, out tokenResolutions, out locals, out parameters);

            this._methodBody = new SynthesizedMethodBodyDecorator(
                null,
                locals,
                code);

            this._parameters = parameters;
            this._tokenResolutions = tokenResolutions;
        }

        public override IEnumerable<IParameter> GetParameters()
        {
            return this._parameters;
        }

        public override IMethodBody GetMethodBody(IGenericContext genericContext = null)
        {
            return this._methodBody;
        }

        public override IModule Module
        {
            get { return new SynthesizedModuleResolver(null, this._tokenResolutions); }
        }
    }
}
